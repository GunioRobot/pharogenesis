An OBPane is the visual representation of a column in a browser. It contains a morph to display nodes (typically a PluggableListMorph) and (optionally) a morph for communicating with the column's filter. It's main responsibility is to lay out its submorphs as the filter controls are added and removed.

iVars:

model	- the OBColumn that controls the node list displayed in this pane
list		- the morph which displays the node list, usually a PluggableListMorph
button	- the morph which controls the column's filter, usually an OBRadioButtonBar.