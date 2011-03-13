convertStepList
	"Convert the old-style step list (an Array of Arrays) into the new-style StepMessage heap"
	| newList wakeupTime morphToStep |

	(stepList isKindOf: Heap) ifTrue:[
		^stepList sortBlock: self stepListSortBlock	"ensure that we have a cleaner block"
	].
	newList _ Heap sortBlock: self stepListSortBlock.
	stepList do:[:entry|
		wakeupTime _ entry at: 2.
		morphToStep _ entry at: 1.
		newList add: (
			StepMessage
				scheduledAt: wakeupTime
				stepTime: nil
				receiver: morphToStep
				selector: #stepAt:
				arguments: nil).
	].
	stepList _ newList.