setAttributesIn: aText fromRanges: ranges
	| charAttr defaultAttr attr newRuns newValues lastAttr | 		

	defaultAttr := self attributesFor: #default.
	charAttr := Array new: aText size.
	1 to: charAttr size do: [:i | charAttr at: i put: defaultAttr].
	ranges do: [:range |
		(attr := self attributesFor: range type) ifNotNil:[
			range start to: range end do: [:i | charAttr at: i put: attr]]].
	newRuns := OrderedCollection new: charAttr size // 10.
	newValues := OrderedCollection new: charAttr size // 10.
	1 to: charAttr size do: [:i |
		i = 1 
			ifTrue: [
				newRuns add: 1.
				lastAttr := newValues add: (charAttr at: i)]
			ifFalse:[
				(charAttr at: i) = lastAttr
					ifTrue: [newRuns at: newRuns size put: (newRuns last + 1)]
					ifFalse: [
						newRuns add: 1.
						lastAttr := newValues add: (charAttr at: i)]]].	
	aText runs: (RunArray runs: newRuns values: newValues)
	