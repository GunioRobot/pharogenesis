updateWidgets
"update the receiver's widgets"
	acceptWidget isNil
		ifFalse: [""
			acceptWidget color: Color lightGreen;
				 borderWidth: 2;
				 borderColor: #raised].
	cancelWidget isNil
		ifFalse: [""
			cancelWidget color: Color lightRed;
				 borderWidth: 2;
				 borderColor: #raised].
	""
	serverNameLabelWidget isNil
		ifFalse: [""
			serverNameLabelWidget color: self paneColor lighter;
				 borderColor: #raised].
	portLabelWidget isNil
		ifFalse: [""
			portLabelWidget color: self paneColor lighter;
				 borderColor: #raised]