registerForNotifications
	(Smalltalk hasClassNamed: #SystemChangeNotifier)
		ifTrue: [self registerForNotificationsFrom: 
					(Smalltalk at: #SystemChangeNotifier) uniqueInstance]				
		ifFalse: [Utilities addDependent: self]
