unstyledTextFrom: aText
	"Re-implemented so that TextActions are not removed from aText"
	| answer |	
	answer := super unstyledTextFrom: aText.
	aText runs withStartStopAndValueDo:[:start :stop :attribs|
		(attribs detect: [:each | each isKindOf: TextAction] ifNone:[nil])
			ifNotNil:[
				attribs do: [:eachAttrib | answer addAttribute: eachAttrib from: start to: stop]]].
	^answer