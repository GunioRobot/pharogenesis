linkFor: string from: peer storingTo: aList page: aPage
	| uString placeID |

	uString _ string asUppercase.
	(uString beginsWith: 'APPEND HERE') ifTrue: [
		placeID _ uString copyFrom: (13 min: uString size) to:
uString size.
		^'<a href="', aPage url, '.insert.', placeID ,'">','Append
Here','</a>'].
			"later an image here"
	^self linkFor: string from: peer storingTo: aList.
