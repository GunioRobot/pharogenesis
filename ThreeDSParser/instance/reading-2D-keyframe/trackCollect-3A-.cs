trackCollect: aBlock
	"Read keyframes, return Array with values of aBlock "
	
	| flags keys frame unknown1 paramFlags params paramMask param |
	"Track header"
	flags := self short.
	unknown1 := (1 to: 2) collect: [:i | self long].
	keys := self long.
	"Log"
	log == nil ifFalse: [log crtab: indent; nextPutAll: 'Flags: '; print: flags; 
		nextPutAll: ' {', flags hex, '}';
		nextPutAll: ' Unknown: '; print: unknown1].
	"Keys"
	^(1 to: keys) collect: [:i |
		params := nil.
		"Key header"
		frame := self long.
		paramFlags := self short.
		"Log"
		log == nil ifFalse: [log crtab: indent; print: frame; nextPutAll: ':	['; print: paramFlags; nextPutAll: ']	'].
		"Params, if not default"
		paramFlags = 0 ifFalse: [
			params := Dictionary new.
			paramMask := 1.
			#(tension: continuity: bias: easeTo: easeFrom:) with: 
			#(true true true false false) do: [:what :symmetric |
				param := (paramFlags bitAnd: paramMask) ~= 0
					ifTrue: [self float]
					ifFalse: [0.0].
				log == nil ifFalse: [log crtab: indent+1; print: param; space; nextPutAll: what; space;
					print: (symmetric ifTrue: [25 * (1 + param)] ifFalse: [param * 50]) rounded].
				params at: what put: param.
				paramMask := paramMask bitShift: 1].
			log == nil ifFalse: [log crtab: indent+1]].
		log == nil ifFalse: [log nextPutAll: 'Data: '].
		"Data"
		frame -> (aBlock value: params)]