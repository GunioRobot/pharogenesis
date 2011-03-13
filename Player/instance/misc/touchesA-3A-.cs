touchesA: aPrototypicalPlayer

	| envelope myBounds trueNeighbor trueGoal trueSelf |

	aPrototypicalPlayer ifNil: [^false].
	envelope _ costume owner ifNil: [^false].
	myBounds _ costume bounds.
	trueSelf _ costume renderedMorph.
	trueGoal _ aPrototypicalPlayer costume renderedMorph.
	envelope submorphs do: [ :each |
		trueNeighbor _ each renderedMorph.
		(trueNeighbor == trueGoal or: [trueNeighbor == trueSelf]) ifFalse: [
			(myBounds intersects: each bounds) ifTrue: [
				(trueGoal appearsToBeSameCostumeAs: trueNeighbor) ifTrue: [ ^true].
			].
		].
	].
	^false
