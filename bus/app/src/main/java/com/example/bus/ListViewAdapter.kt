package com.example.bus

import android.annotation.SuppressLint
import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.TextView
import org.json.JSONException
import java.util.*

class ListViewAdapter(
    var contextAdapter: Context,
    var listLayout: Int,
    field: Int,
    var itemList: ArrayList<List<String>>
) : ArrayAdapter<List<String>>(contextAdapter, listLayout, field, itemList) {
    @SuppressLint("SetTextI18n", "ViewHolder")
    override fun getView(
        position: Int,
        convertView: View?,
        parent: ViewGroup
    ): View {
        val inflater =
            context.getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater
        val listViewItem = inflater.inflate(listLayout, null, false)
        //todo name
        val name = listViewItem.findViewById<TextView>(R.id.textViewRoute)
        val dateTime = listViewItem.findViewById<TextView>(R.id.textViewDateTime)
        val status = listViewItem.findViewById<TextView>(R.id.textViewStatus)
        val buttonAddToCart = listViewItem.findViewById<Button>(R.id.buttonAddToCart)

        val textViewQuantity = listViewItem.findViewById<TextView>(R.id.textViewQuantity)
        val textViewRoute = listViewItem.findViewById<TextView>(R.id.textViewRoute)
        val textViewPrice = listViewItem.findViewById<TextView>(R.id.textViewPrice)
        val textViewTotalPrice = listViewItem.findViewById<TextView>(R.id.textViewTotalPrice)


        if (dateTime != null) {
            name.text = itemList[position][0] ?: ""
            dateTime.text = itemList[position][1] ?: "" + " - " + itemList[position][2] ?: ""
            status.text = itemList[position][3] ?: ""
        } else {
            textViewQuantity.text = itemList[position][0]
            textViewRoute.text = itemList[position][1]
            textViewPrice.text = itemList[position][2]
            textViewTotalPrice.text = itemList[position][3]
        }
        return listViewItem
    }

}