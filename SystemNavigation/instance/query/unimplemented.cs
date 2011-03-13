unimplemented
	"Answer an Array of each message that is sent by an expression in a method but is not implemented by any object in the system."

	| all unimplemented entry |
	all := IdentitySet new: Symbol instanceCount * 2.
	Cursor wait showWhile: 
		[self allBehaviorsDo: [:cl | cl selectorsDo: [:aSelector | all add: aSelector]]].

	unimplemented := IdentityDictionary new.
	Cursor execute showWhile: [
		self allBehaviorsDo: [:cl |
			 cl selectorsDo: [:sel |
				(cl compiledMethodAt: sel) messages do: [:m |
					(all includes: m) ifFalse: [
						entry := unimplemented at: m ifAbsent: [Array new].
						entry := entry copyWith: (cl name, '>', sel).
						unimplemented at: m put: entry]]]]].
	^ unimplemented
