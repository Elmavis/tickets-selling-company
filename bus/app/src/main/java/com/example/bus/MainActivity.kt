package com.example.bus

import android.os.Bundle
import android.view.View
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import androidx.constraintlayout.widget.ConstraintLayout
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.StringRequest
import com.android.volley.toolbox.Volley
import org.json.JSONArray
import org.json.JSONException
import org.json.JSONObject
import java.io.UnsupportedEncodingException
import kotlin.collections.ArrayList

class MainActivity : AppCompatActivity() {
    var listView: ListView? = null
    private val JSON_URL = "http://192.168.100.2:3000" // UTF-8
    private val userId = 2

    enum class ViewTypes {
        Account, Cart, Routes
    }

    var currentView = ViewTypes.Routes
    var destinationName = "Minsk"
    var departureName = "Vitebsk"
    var departureDate = "20.07.2015"

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_search)
        listView = findViewById<View>(R.id.listView) as ListView

        val constraintLayoutSearch = findViewById<ConstraintLayout>(R.id.constraintLayoutSearch)

        val buttonAccount = findViewById<Button>(R.id.buttonAccount)
        val buttonCart = findViewById<Button>(R.id.buttonCart)
        val buttonRotes = findViewById<Button>(R.id.buttonRoutes)
        val buttonSearch = findViewById<Button>(R.id.buttonSearch)

        buttonAccount.setOnClickListener {
            currentView = ViewTypes.Account
            constraintLayoutSearch.visibility = View.GONE
            loadJSONFromURL()
        }
        buttonCart.setOnClickListener {
            currentView = ViewTypes.Cart
            constraintLayoutSearch.visibility = View.GONE
            loadJSONFromURL()
        }
        buttonRotes.setOnClickListener {
            currentView = ViewTypes.Routes
            constraintLayoutSearch.visibility = View.VISIBLE
        }

        val textViewDestinationName = findViewById<EditText>(R.id.editTextDestinationName)
        val textViewDepartureName = findViewById<EditText>(R.id.editTextDepartureName)
        val textViewDepartureDate = findViewById<EditText>(R.id.editTextDepartureDate)

        buttonSearch.setOnClickListener {
            destinationName = textViewDestinationName.text.toString()
            departureName = textViewDepartureName.text.toString()
            departureDate = textViewDepartureDate.text.toString()
            loadJSONFromURL()
        }


        //todo user id properties
        //todo user id get from server

        //currentView = intent.extras?.get("view") as ViewTypes
        loadJSONFromURL()
    }

    fun onButtonClicked() {

    }

    private fun loadJSONFromURL() {
        val url = JSON_URL + when (currentView) {
            ViewTypes.Account -> ""//"/user-tickets?userId=$userId"
            ViewTypes.Cart -> "/GetRoutsOfCart?userId=$userId"
            ViewTypes.Routes -> "/GetRoutesByNamesAndDate?destinationName=$destinationName&departureName=$departureName&departureDate=$departureDate"
        }
        val progressBar =
            findViewById<View>(R.id.progressBar) as ProgressBar
        progressBar.visibility = ListView.VISIBLE
        val stringRequest = StringRequest(
            Request.Method.GET, url,
            Response.Listener { response ->
                progressBar.visibility = View.INVISIBLE
                try {
                    var responseUtf8 = JSONObject(response)//JSONObject(response)

                    val jsonArray = when (currentView) {
                        ViewTypes.Routes, ViewTypes.Cart -> responseUtf8.getJSONArray("tickets")
                        else -> responseUtf8.getJSONArray("tickets")
                    }
                    val jsonListItems = getArrayListFromJSONArray(jsonArray)
                    val listItems = getStringList(jsonListItems)
                    val adapter: ListAdapter = ListViewAdapter(
                        applicationContext,
                        when(currentView) { ViewTypes.Routes -> R.layout.row_routes else -> R.layout.row_cart},
                        R.id.textViewRoute,
                        listItems
                    )
                    listView!!.adapter = adapter
                } catch (e: JSONException) {
                    e.printStackTrace()
                }
            },
            Response.ErrorListener { error ->
                Toast.makeText(applicationContext, error.message, Toast.LENGTH_SHORT)
                    .show()
            })
        val requestQueue = Volley.newRequestQueue(this)
        requestQueue.add(stringRequest)
    }

    private fun getArrayListFromJSONArray(jsonArray: JSONArray?): ArrayList<JSONObject> {
        val aList = ArrayList<JSONObject>()
        try {
            if (jsonArray != null) {
                for (i in 0 until jsonArray.length()) {
                    aList.add(jsonArray.getJSONObject(i))
                }
            }
        } catch (js: JSONException) {
            js.printStackTrace()
        }
        return aList
    }

    private fun getStringList(jsonList: ArrayList<JSONObject>): ArrayList<List<String>> {
        val stringList = ArrayList<List<String>>()
        for (jsonObject in jsonList) {
            val oneElementList = ArrayList<String>()
            when (currentView) {
                ViewTypes.Cart -> {
                    oneElementList.add(jsonObject.getString("Quantity"))
                    oneElementList.add(jsonObject.getString("Route"))
                    oneElementList.add(jsonObject.getString("Price"))
                    oneElementList.add(jsonObject.getString("TotalPrice"))
                }
                ViewTypes.Account, ViewTypes.Routes -> {
                    oneElementList.add(jsonObject.getString("Route"))
                    oneElementList.add(jsonObject.getString("DepartureDateTime"))
                    oneElementList.add(jsonObject.getString("ArrivalDateTime"))
                    oneElementList.add(jsonObject.getString("Status"))
                }
            }
            stringList.add(oneElementList)
        }
        return stringList
    }

    companion object {

        fun EncodingToUTF8(response: String): String? {
            var response = response
            response = try {
                val code = response.toByteArray(charset("ISO-8859-1"))
                String(code, Charsets.UTF_8)
            } catch (e: UnsupportedEncodingException) {
                e.printStackTrace()
                return null
            }
            return response
        }
    }
}