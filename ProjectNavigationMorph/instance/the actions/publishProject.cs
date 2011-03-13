publishProject

	(self world ifNil: [^1 beep]) project storeOnServerShowProgressOn: self forgetURL: false.
