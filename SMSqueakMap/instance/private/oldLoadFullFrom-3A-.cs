oldLoadFullFrom: aServerName
	"Contact the SqueakMap at the url <aSqueakMapUrl>
	and load a full map from scratch."

	| url  zipped full |
	url _ 'http://', aServerName, '/sm/loadgz?mapversion=', '1.0'.
	Transcript show: 'Fetch: ', (Time millisecondsToRun: [ zipped _ (HTTPSocket httpGet: url) contents]) asString, ' ms';cr.
	Transcript show: 'Size: ', zipped size asString, ' bytes';cr.
	Transcript show: 'Decompress time: ', (Time millisecondsToRun: [full _ (GZipReadStream on: zipped) upToEnd]) asString, ' ms';cr.
	(self checkVersion: full)
		ifTrue:[
			Transcript show: 'Save full log: ', (Time millisecondsToRun: [
			self createNewLogWithInitialContent: full]) asString, ' ms';cr.
			Transcript show: 'Full reload from log: ', (Time millisecondsToRun: [
			self reloadLog]) asString, ' ms';cr.]