storePreferencesIn: aFileName 
	| stream |
	#(#Prevailing #PersonalPreferences )  do:[:ea | Parameters  removeKey:ea  ifAbsent:[]].
	stream := ReferenceStream  fileNamed:aFileName.
	stream  nextPut:Parameters.
	stream  nextPut:self dictionaryOfPreferences.
	stream  nextPut:World fillStyle.
	stream close