meshData
	"Subchunk of scene"
	| renderObjects globals |
	globals := Dictionary 
				with: (#constants -> Dictionary new) 
				with: (#cameras -> Dictionary new) 
				with: (#lights -> Dictionary new)
				with: (#materials -> Dictionary new).
	renderObjects := Dictionary with: (#globals -> globals).				
	self recognize: #(
		(16r4000 namedObject)
		(16r2100 materialColor ambientColor)
		(16r1100 cString bgBitmap)
		(16rAFFF materialEntry ->)
		(16r1200 materialColor backgroundColor)
		(16r1300 verticalGradient ->)
		) do: [:item | 
			item key == #verticalGradient
				ifTrue:[globals add: item].
			item key == #materialEntry
				ifTrue:[(globals at: #materials) add: item value].
			item key == #backgroundColor
				ifTrue: [(globals at: #constants) at: item key asString put: item value].
			item key == #ambientColor
				ifTrue: [(globals at: #constants) at: item key asString put: item value] ifFalse:[
			item key == #bgBitmap
				ifTrue: [(globals at: #constants) at: item key asString put: item value] ifFalse:[
			item key == #triMesh 
				ifTrue: [renderObjects add: item value] ifFalse: [
			item key == #light 
				ifTrue: [(globals at: #lights) add: item value] ifFalse: [
			item key == #camera 
				ifTrue: [(globals at: #cameras) add: item value]]]]]].
	^renderObjects