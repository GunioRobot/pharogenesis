colorMap: map
	"See last part of BitBlt comment. 6/18/96 tk"
	colorMap _ map.
	"As long as we need to fix problems with colorMaps"
	map ifNotNil:[
		(map isKindOf: ColorMap) ifFalse:[
			map size < 256 ifTrue:[
				colorMap _ ColorMap shifts: nil masks: nil colors: map.
			] ifFalse:[ sourceForm 
					ifNil:["Can't fix -- ignore". colorMap _ nil]
					ifNotNil:[colorMap _ sourceForm colormapIfNeededFor: destForm]]]].
