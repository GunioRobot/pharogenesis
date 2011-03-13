annotationInfo 
	"Answer a list of pairs characterizing all the available kinds of annotations; in each pair, the first element is a symbol representing the info type, and the second element is a string providing the corresponding balloon help"

	^ #(

		(timeStamp			'The time stamp of the last submission of the method.')
		(firstComment		'The first comment in the method, if any.')
		(messageCategory	'Which method category the method lies in')
		(sendersCount		'A report of how many senders there of the message.')
		(implementorsCount	'A report of how many implementors there are of the message.')
		(recentChangeSet	'The most recent change set bearing the method.')
		(allChangeSets		'A list of all change sets bearing the method.')
		(priorVersionsCount	'A report of how many previous versions there are of the method' )
		(priorTimeStamp		'The time stamp of the penultimate submission of the method, if any'))