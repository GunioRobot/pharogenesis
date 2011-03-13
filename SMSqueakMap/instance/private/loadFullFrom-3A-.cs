loadFullFrom: aServerName
	"Contact the SqueakMap at the url <aSqueakMapUrl>
	and load a full map from scratch."

	| url  zipped |
	url := 'http://', aServerName, '/loadgz?mapversion=', SMSqueakMap version, '&checkpoint=', checkpointNumber asString.
	Transcript show: 'Fetch: ', (Time millisecondsToRun: [ zipped := (HTTPSocket httpGet: url) contents]) asString, ' ms';cr.
	Transcript show: 'Size: ', zipped size asString, ' bytes';cr.
	((self checkVersion: zipped) and: [zipped ~= 'UPTODATE'])
		ifTrue:[
			Transcript show: 'Save checkpoint to disk: ', (Time millisecondsToRun: [
			self saveCheckpoint: zipped]) asString, ' ms';cr.
			Transcript show: 'Full reload from checkpoint: ', (Time millisecondsToRun: [
			self reload]) asString, ' ms';cr.]