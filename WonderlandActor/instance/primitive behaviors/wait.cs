wait
	"Creates an animation where the object merely waits for one second"

	| anim |

	anim _ RelativeAnimation new.

	anim object: self
			update: [:temp | temp ]
			getStartState: [ Interpolateable value: 0 ]
			getEndState: [ 1.0 ]
			getReverseState: [ 1.0 ]
			style: [:elapsed :total | WonderlandStyle abruptlyAfter: elapsed outOf: total]
			duration: 1.0
			undoable: true
			inWonderland: myWonderland.

	^ anim.