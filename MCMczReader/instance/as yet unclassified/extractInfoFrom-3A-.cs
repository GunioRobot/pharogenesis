extractInfoFrom: dict
	^ self infoCache at: (dict at: #id) ifAbsentPut:
		[MCVersionInfo
			name: (dict at: #name)
			id: (UUID fromString: (dict at: #id))
			message: (dict at: #message)
			date: ([Date fromString: (dict at: #date) ] on: Error do: [ :ex | ex return: nil ])
			time: ([ Time fromString:(dict at: #time)] on: Error do: [ :ex | ex return: nil ])
			author: (dict at: #author)
			ancestors: ((dict at: #ancestors) collect: [:ea | self extractInfoFrom: ea])
			stepChildren: ((dict at: #stepChildren ifAbsent: [#()]) collect: [:ea | self extractInfoFrom: ea])]