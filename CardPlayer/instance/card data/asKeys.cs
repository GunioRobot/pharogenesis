asKeys
	| keys kk vd gotData |
	"Take my fields, tokenize the text, and return as an array in the same order as variableDocks.  Simple background fields on the top level.  If no data, return nil."

	keys _ self class variableDocks copy.
	gotData _ false.
	1 to: keys size do: [:ind |
		kk _ nil.
		vd _ self class variableDocks at: ind.
		vd type == #text ifTrue: [
			kk _ (self perform: vd playerGetSelector) string
					findTokens: Character separators.
			kk isEmpty ifTrue: [kk _ nil] ifFalse: [gotData _ true]].
		keys at: ind put: kk].
	^ gotData ifTrue: [keys] ifFalse: [nil]