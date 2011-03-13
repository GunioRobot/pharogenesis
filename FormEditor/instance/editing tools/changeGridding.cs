changeGridding
	"Allow the user to change the values of the horizontal and/or vertical 
	grid modules. Does not change the primary tool."

	| response gridInteger gridX gridY |
	gridX := togglegrid x.
	gridY := togglegrid y.
	response := UIManager default
		request:
'Current horizontal gridding is: ', gridX printString, '.
Type new horizontal gridding.'.
	response isEmpty
		ifFalse: 
			[gridInteger := Integer readFromString: response.
			gridX := ((gridInteger max: 1) min: Display extent x)].
	response := UIManager default
		request:
'Current vertical gridding is: ', gridY printString, '.
Type new vertical gridding.'.
	response isEmpty
		ifFalse: 
			[gridInteger := Integer readFromString: response.
			gridY := ((gridInteger max: 1) min: Display extent y)].
	xgridOn ifTrue: [grid := gridX @ grid y].
	ygridOn ifTrue: [grid := grid x @ gridY].
	togglegrid := gridX @ gridY.
	tool := previousTool