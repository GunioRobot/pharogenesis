materialEntry
	"Globally defined materials"
	| name materialSpec |
	name := 'unknown'.
	materialSpec := Dictionary new.
	self recognize: #(
		(16rA000 cString name)
		(16rA010 materialColor ambient)
		(16rA020 materialColor diffuse)
		(16rA030 materialColor specular)
		(16rA200 textureMap texture)
		(16rA040 percentageChunk shininessHighlight)
		(16rA041 percentageChunk shininessColorScale)
		) do: [:item | 
			item key == #name ifTrue:[
				log == nil ifFalse: [log crtab: indent+1; print: item value].
				name := item value.
			] ifFalse:[
				item key == #texture ifTrue:[materialSpec addAll: item value]
				ifFalse:[materialSpec at: item key put: item value]]].
	materialSpec at: #name put: name.
	^name -> (self materialClass from3DS: materialSpec)