addCommandsTo: aMenu
	aMenu add: 'set user name' target: self selector: #setUserName.
	aMenu 
		balloonTextForLastItem: 'Specify the ''From:'' user name for new messages'.
	aMenu add: 'set cc: list' target: self selector: #setCCList.
	aMenu 
		balloonTextForLastItem: 'Specify a cc: list that is added to each new message'.
	aMenu add: 'set POP server' target: self selector: #setPopServer.
	aMenu 
		balloonTextForLastItem: 'Specify which (POP3) server to check for new messages'.
	aMenu add: 'set POP username' target: self selector: #setPopUserName.
	aMenu 
		balloonTextForLastItem: 'Specify the username to use when checking for new messages'.
	aMenu add: 'set POP password' target: self selector: #setPopPassword.
	aMenu 
		balloonTextForLastItem: 'Specify the password to use when checking for new messages'.
	aMenu add: 'set SMTP server' target: self selector: #setSmtpServer.
	aMenu 
		balloonTextForLastItem: 'Specify which (SMTP) server to use when sending messages'.
