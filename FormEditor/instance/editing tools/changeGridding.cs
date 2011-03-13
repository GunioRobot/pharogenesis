changeGridding
	"Allow the user to change the values of the horizontal and/or vertical 
	grid modules. Does not change the primary tool."

	| response gridInteger gridX gridY |
	gridX _ togglegrid x.
	gridY _ togglegrid y.
	response _ FillInTheBlank
		request:
'Current horizontal gridding is: ', gridX printString, '.
Type new horizontal gridding.'.
	response isEmpty
		ifFalse: 
			[gridInteger _ Integer readFromString: response.
			gridX _ ((gridInteger max: 1) min: Display extent x)].
	response _ FillInTheBlank
		request:
'Current vertical gridding is: ', gridY printString, '.
Type new vertical gridding.'.
	response isEmpty
		ifFalse: 
			[gridInteger _ Integer readFromString: response.
			gridY _ ((gridInteger max: 1) min: Display extent y)].
	xgridOn ifTrue: [grid _ gridX @ grid y].
	ygridOn ifTrue: [grid _ grid x @ gridY].
	togglegrid _ gridX @ gridY.
	tool _ previousTool