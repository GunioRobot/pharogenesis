pointSize: aNumber
	"Set the current point size"
	^self primRender: handle setProperty: 3 toInteger: aNumber.