loadUpdatesFrom: aServerName
	"Contact the SqueakMap at the url <aServerName>
	and load needed updates from it based on our last known
	transaction number which we send as an urlencoded argument.
	If the master answers 'DO FULL!' we issue a full load instead.
	If the master answers 'STALE SERVER!' we notify the user and bail out."

	| url  zipped updates |
	url _ 'http://', aServerName, '/sm/updatesgz?mapversion=', '1.0', '&transaction=', transactionCounter asString.
	Transcript show: 'Fetch: ', (Time millisecondsToRun: [ zipped _ (HTTPSocket httpGet: url) contents]) asString, ' ms';cr.
	Transcript show: 'Size: ', zipped size asString, ' bytes';cr.
	Transcript show: 'Decompress time: ', (Time millisecondsToRun: [updates _ (GZipReadStream on: zipped) upToEnd]) asString, ' ms';cr.
	(self checkVersion: updates)
		ifTrue:[
			updates = 'STALE SERVER!' ifTrue:[
				self inform: 'Server ', aServerName printString, ' is stale! Aborting update.'.
				^self].
			updates = 'DO FULL!' ifTrue:[
				Transcript show: 'Master can not deliver updates this far back, falling back on full load.';cr.
				^self loadFullFrom: aServerName].
			Transcript show: 'Load updates with logging time: ', (Time millisecondsToRun: [self loadUpdatesFrom: (ReadStream on: updates) log: true]) asString, ' ms';cr.]