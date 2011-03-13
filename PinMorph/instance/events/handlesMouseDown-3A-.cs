handlesMouseDown: evt
	^ (evt optionKeyPressed | evt commandKeyPressed) not