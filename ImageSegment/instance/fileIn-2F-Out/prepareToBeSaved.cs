prepareToBeSaved
	"Prepare objects in outPointers to be written on the disk.  They must be able to match up with existing objects in their new system.  outPointers is already a copy.
	Classes are already converted to a DiskProxy.  
	Associations in outPointers:
1) in Smalltalk.
2) in a classPool.
3) in a shared pool.
4) A pool dict pointed at directly"

| left pool myClasses outIndexes key |
myClasses _ Set new.
arrayOfRoots do: [:aRoot | aRoot class class == Metaclass ifTrue: [myClasses add: aRoot]].
outIndexes _ IdentityDictionary new.
outPointers withIndexDo: [:anOut :ind | 
	anOut isVariableBinding ifTrue: [
		(myClasses includes: anOut value)
			ifFalse: [outIndexes at: anOut put: ind]
			ifTrue: [(Smalltalk associationAt: anOut key ifAbsent: [3]) == anOut 
				ifTrue: [outPointers at: ind put: 
					(DiskProxy global: #Smalltalk selector: #associationDeclareAt: 
						args: (Array with: anOut key))]
				ifFalse: [outIndexes at: anOut put: ind]
				]].
	(anOut isKindOf: Dictionary) ifTrue: ["Pools pointed at directly"
		(key _ Smalltalk keyAtIdentityValue: anOut ifAbsent: [nil]) ifNotNil: [
			outPointers at: ind put: 
				(DiskProxy global: key selector: #yourself args: #())]].
	anOut isMorph ifTrue: [outPointers at: ind put: 
		(StringMorph contents: anOut printString, ' that was not counted')]
	].
left _ outIndexes keys asSet.
left size > 0 ifTrue: ["Globals"
	(left copy) do: [:assoc |	"stay stable while delete items"
		(Smalltalk associationAt: assoc key ifAbsent: [3]) == assoc ifTrue: [
			outPointers at: (outIndexes at: assoc) put: 
				(DiskProxy global: #Smalltalk selector: #associationAt: 
					args: (Array with: assoc key)).
			left remove: assoc]]].
left size > 0 ifTrue: ["Class variables"
	Smalltalk allClassesDo: [:cls | cls classPool size > 0 ifTrue: [
		(left copy) do: [:assoc |	"stay stable while delete items"
			(cls classPool associationAt: assoc key ifAbsent: [3]) == assoc ifTrue: [
				outPointers at: (outIndexes at: assoc) put: 
					(DiskProxy new global: cls name
						preSelector: #classPool
						selector: #associationAt: 
						args: (Array with: assoc key)).
				left remove: assoc]]]]].
left size > 0 ifTrue: ["Pool variables"
	Smalltalk associationsDo: [:poolAssoc |
		poolAssoc value class == Dictionary ifTrue: ["a pool"
			pool _ poolAssoc value.
			(left copy) do: [:assoc |	"stay stable while delete items"
				(pool associationAt: assoc key ifAbsent: [3]) == assoc ifTrue: [
					outPointers at: (outIndexes at: assoc) put: 
						(DiskProxy global: poolAssoc key selector: #associationAt: 
							args: (Array with: assoc key)).
					left remove: assoc]]]]].
left size > 0 ifTrue: [
	"If points to class in arrayOfRoots, must deal with it separately"
	"OK to have obsolete associations that just get moved to the new system"
	self inform: 'extra associations'.
	left inspect].
