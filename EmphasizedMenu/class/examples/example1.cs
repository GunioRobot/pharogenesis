example1
	"EmphasizedMenu example1"

	^ (self
		selections: #('how' 'well' 'does' 'this' 'work?' ) 
		emphases: #(#bold #plain #italic #struckOut #plain ))
			startUpWithCaption: 'A Menu with Emphases'