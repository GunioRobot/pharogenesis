password: pp

	passwordHolder _ Password new.
	pp class == String 
		ifTrue: [passwordHolder cache: pp. ^ self].
	pp isInteger 
		ifTrue: [passwordHolder sequence: pp]
		ifFalse: [passwordHolder _ pp].