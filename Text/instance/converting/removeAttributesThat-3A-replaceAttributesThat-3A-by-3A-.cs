removeAttributesThat: removalBlock replaceAttributesThat: replaceBlock by: convertBlock
	"Enumerate all attributes in the receiver. Remove those passing removalBlock and replace those passing replaceBlock after converting it through convertBlock"
	| added removed new |
	"Deliberately optimized for the no-op default."
	added _ removed _ nil.
	runs withStartStopAndValueDo: [ :start :stop :attribs | 
		attribs do: [ :attrib |
			(removalBlock value: attrib) ifTrue:[
				removed ifNil:[removed _ WriteStream on: #()].
				removed nextPut: {start. stop. attrib}.
			] ifFalse:[
				(replaceBlock value: attrib) ifTrue:[
					removed ifNil:[removed _ WriteStream on: #()].
					removed nextPut: {start. stop. attrib}.
					new _ convertBlock value: attrib.
					added ifNil:[added _ WriteStream on: #()].
					added nextPut: {start. stop. new}.
				].
			].
		].
	].
	(added == nil and:[removed == nil]) ifTrue:[^self].
	"otherwise do the real work"
	removed ifNotNil:[removed contents do:[:spec|
		self removeAttribute: spec last from: spec first to: spec second]].
	added ifNotNil:[added contents do:[:spec|
		self addAttribute: spec last from: spec first to: spec second]].