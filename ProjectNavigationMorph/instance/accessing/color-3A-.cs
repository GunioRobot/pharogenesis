color: newColor

	| buttonColor |

	super color: newColor.
	buttonColor _ color darker.
	self submorphsDo: [:m | m submorphsDo: [:n | n color: buttonColor]]