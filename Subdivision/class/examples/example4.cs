example4	"Subdivision example4"
	"A nasty self-intersecting shape"
	"Same as example2 but marking edges"
	| ptList subdivision |
	ptList _ {
		50@100. 
		100@100.
		150@100.
		150@150.
		100@150.
		100@100.
		100@50.
		300@50.
		300@300.
		50@300.
	}.
	subdivision _ (self points: ptList) constraintOutline: ptList; yourself.
	subdivision markExteriorEdges.
	self exampleDraw: subdivision points: ptList.
