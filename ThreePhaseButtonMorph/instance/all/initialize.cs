initialize

	super initialize.
	state _ #off.
	target _ nil.
	actionSelector _ #flash.
	arguments _ EmptyArray.
	actWhen _ #buttonUp.

	"self on: #mouseStillDown send: #dragIfAuthoring: to: self."
		"real move should include a call on dragIfAuthoring: "