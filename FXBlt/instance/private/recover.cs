recover
	"Recover after a BitBlt operation has failed. Return true if the
	copyBits operation should be tried again."

	"As long as we need to fix problems with colorMaps"
	colorMap ifNotNil:[
		(colorMap isKindOf: ColorMap) ifFalse:[
			colorMap size < 256 ifTrue:[
				colorMap _ ColorMap shifts: nil masks: nil colors: colorMap.
			] ifFalse:[ sourceForm 
					ifNil:["Can't fix -- ignore". colorMap _ nil]
					ifNotNil:[colorMap _ sourceForm colormapIfNeededFor: destForm]].
		^true "try again"]].

	"Check for compressed source, destination or halftone forms"
	((sourceForm isKindOf: Form) and: [sourceForm unhibernate])
		ifTrue: [^true]. "try again"
	((destForm isKindOf: Form) and: [destForm unhibernate])
		ifTrue: [^true]. "try again"
	((halftoneForm isKindOf: Form) and: [halftoneForm unhibernate])
		ifTrue: [^true]. "try again"

	^false "unable to recover"