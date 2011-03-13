An OBRadioButtonBar is similar to a PluggableListMorph except that it displays a row of buttons rather than a vertical list. Clicking on a button selects it.

model				- the model for this button bar
buttons			- a collection of OBButtonModels, which are derived from the model's list
selection			- the index of the currently selected button
getListSelector	 	- the message for getting the list of labels for the buttons
getSelectionSelector	- the message for getting the index of the currently selected item
setSelectionSelector	- the message for informing the model that a button has been clicked