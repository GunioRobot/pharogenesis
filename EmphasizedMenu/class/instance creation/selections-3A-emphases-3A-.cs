selections: selList emphases: emphList
	"Answer an instance of the receiver with the given selections and emphases.  "

	^ (self selections: selList) emphases: emphList

"(EmphasizedMenu selections: #('how' 'well' 'does' 'this' 'work?') emphases: #(bold 0 italic struckOut plain)) startUp" 