getNewerVersionIfAvailable

	(self world ifNil: [^Beeper beep]) project loadFromServer: true.

