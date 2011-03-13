writeFileNamed: localFileName fromDirectory: localDirectory toServer: primaryServerDirectory

	| local resp gifFileName f |

	local _ localDirectory oldFileNamed: localFileName.
	resp _ primaryServerDirectory putFile: local named: localFileName retry: false.
	local close.
	resp == true ifFalse: [
		self inform: 'the primary server of this project seems to be down (',
							resp printString,')'. 
		^ self
	].

	gifFileName _ self name,'.gif'.
	localDirectory deleteFileNamed: gifFileName ifAbsent: [].
	local _ localDirectory fileNamed: gifFileName.
	thumbnail ifNil: [
		(thumbnail _ Form extent: 100@80) fillColor: Color orange
	] ifNotNil: [
		thumbnail unhibernate.
	].
	f _ thumbnail colorReduced.  "minimize depth"
	f depth > 8 ifTrue: [
		f _ thumbnail asFormOfDepth: 8
	].
	GIFReadWriter putForm: f onStream: local.
	local close.

	local _ localDirectory oldFileNamed: gifFileName.
	resp _ primaryServerDirectory putFile: local named: gifFileName retry: false.
	local close.

	primaryServerDirectory updateProjectInfoFor: self.
	primaryServerDirectory sleep.	"if ftp, close the connection"
