smartFillRoots: dummy
	| refs known ours ww blockers |
	"Put all traced objects into my arrayOfRoots.  Remove some
that want to be in outPointers.  Return blockers, an
IdentityDictionary of objects to replace in outPointers."

	blockers _ dummy blockers.
	known _ (refs _ dummy references) size.
	refs fasterKeys do: [:obj | "copy keys to be OK with removing items"
		(obj class == Symbol) ifTrue: [refs removeKey: obj.
known _ known-1].
		(obj class == MultiSymbol) ifTrue: [refs removeKey:
obj.  known _ known-1].
		(obj class == PasteUpMorph) ifTrue: [
			obj isWorldMorph & (obj owner == nil) ifTrue: [
				obj == dummy project world ifFalse: [
					refs removeKey: obj.  known _ known-1.
					blockers at: obj put:
						(StringMorph
contents: 'The worldMorph of a different world')]]].
					"Make a ProjectViewMorph here"
		"obj class == Project ifTrue: [Transcript show: obj; cr]."
		(blockers includesKey: obj) ifTrue: [
			refs removeKey: obj ifAbsent: [known _
known+1].  known _ known-1].
		].
	ours _ dummy project world.
	refs keysDo: [:obj |
			obj isMorph ifTrue: [
				ww _ obj world.
				(ww == ours) | (ww == nil) ifFalse: [
					refs removeKey: obj.  known _ known-1.
					blockers at: obj put:
(StringMorph contents:
								obj
printString, ' from another world')]]].
	"keep original roots on the front of the list"
	(dummy rootObject) do: [:rr | refs removeKey: rr ifAbsent: []].
	^ dummy rootObject, refs fasterKeys asArray.

