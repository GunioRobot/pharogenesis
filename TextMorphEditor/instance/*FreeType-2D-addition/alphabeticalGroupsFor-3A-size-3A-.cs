alphabeticalGroupsFor: familyGroupList size: maxGroupSize
	| alphabetDict alphabetDict2 pendingGroup pendingGroupKeys group key |
	alphabetDict := Dictionary new.
	familyGroupList do:[:each |
		(alphabetDict at: each familyName first ifAbsentPut:[OrderedCollection new])
			add: each].
	alphabetDict2 := Dictionary new.
	pendingGroup := OrderedCollection new.
	pendingGroupKeys :=OrderedCollection new.
	alphabetDict keys asSortedCollection do:[:char |
		group := alphabetDict at: char.
		pendingGroup size + group size <= maxGroupSize
			ifTrue:[
				pendingGroupKeys addLast: char.
				pendingGroup addAll: group]
			ifFalse:[
				pendingGroup ifNotEmpty:[
					key := pendingGroupKeys first asString asUppercase.
					pendingGroupKeys size > 1 
						ifTrue:[key := key, ' - ', pendingGroupKeys last asString asUppercase].
					alphabetDict2 at: key put: pendingGroup].
				pendingGroup := OrderedCollection withAll: group.
				pendingGroupKeys := OrderedCollection with: char]].
	pendingGroup ifNotEmpty:[
		key := pendingGroupKeys first asString asUppercase.
		pendingGroupKeys size > 1 
			ifTrue:[key := key, ' - ', pendingGroupKeys last asString asUppercase].
		alphabetDict2 at: key put: pendingGroup].
	"need to split single char groups at this point. e,g. 'A' may have > maxGroupSize members"
	^alphabetDict2	
	