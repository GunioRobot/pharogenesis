clearViewport: aColor
	"Clear the current viewport using the given color"
	target ifNotNil:[
		target 
			fill: viewport 
			rule: Form over 
			fillColor: aColor asColor
	].