writeFileNamed: localFileName fromDirectory: localDirectory toServer: primaryServerDirectory

	| local resp gifFileName f |

	local _ localDirectory oldFileNamed: localFileName.
	resp _ primaryServerDirectory upLoadProject: local named: localFileName resourceUrl: self resourceUrl retry: false.
	local close.
	resp == true ifFalse: [
		"abandon resources that would've been stored with the project"
		self resourceManager abandonResourcesThat:
			[:loc| loc urlString beginsWith: self resourceUrl].
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

	[local _ StandardFileStream readOnlyFileNamed: (localDirectory fullNameFor: gifFileName).
	(primaryServerDirectory isKindOf: FileDirectory)
		ifTrue: [primaryServerDirectory deleteFileNamed: gifFileName ifAbsent: []].
	resp _ primaryServerDirectory putFile: local named: gifFileName retry: false.
	] on: Error do: [:ex |].
	local close.

	primaryServerDirectory updateProjectInfoFor: self.
	primaryServerDirectory sleep.	"if ftp, close the connection"
