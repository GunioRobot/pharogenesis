sortedInAscendingOrderCollection
" return a collection sorted in an acsending order"
	^ sortedCollection ifNil: [ sortedCollection := ( FloatArray new: 3)at: 1 put: 1.0 ; at: 2 put: 2.0 ; at: 3 put: 3.0 ; yourself ]
	