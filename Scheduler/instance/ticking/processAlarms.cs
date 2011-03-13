processAlarms
	"This method checks all the alarms and processes any that have gone off"
	alarmList do: [:alarm | 
		((alarm checkTime) < currentTime) ifTrue:[
			self removeAlarm: alarm.
			alarm execute]]