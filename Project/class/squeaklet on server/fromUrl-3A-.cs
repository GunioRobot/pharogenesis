fromUrl: urlString
	| serverFile pair pvm projName proj projViewer strm num triple |
	"Load the project, and make a thumbnail to it in the current project.  Replace the old one if necessary.
Project fromUrl: 'http://www.squeak.org/Squeak2.0/2.7segments/Squeak_Easy.pr.gz'.
"
	Smalltalk verifyMorphicAvailability ifFalse: [^ self].
	Smalltalk isMorphic ifFalse: [^ self inform: 
			'Later, allow jumping from MVC to Morphic Projects.'].
	serverFile _ ServerFile new fullPath: urlString.
	(proj _ Project named: (projName _ (serverFile fileName unescapePercents findTokens: '|.') first))
		ifNotNil: ["it appeared" ^ proj enter].
	serverFile type == #http
		ifTrue: [num _ (triple _ serverFile fileName findTokens: '|.') size >= 3 
				ifTrue: [Base64MimeConverter decodeInteger: triple second unescapePercents]
				ifFalse: [0].
			pair _ Array with: serverFile fileName with: num]
		ifFalse: [pair _ self mostRecent: serverFile localName onServer: serverFile].
	"Pair first is name exactly as it is on the server"
	pair first ifNil: ["If none, open a blank project"
		pvm _ ProjectViewMorph newMorphicProjectOn: nil.
		pvm _ pvm findA: ProjectViewMorph.
		(proj _ pvm project) changeSet name: projName.
		projViewer _ Project current findProjectView: projName.
		proj setParent: Project current.
		(projViewer owner isKindOf: SystemWindow) ifTrue: [
				projViewer owner model: proj].
		^ projViewer project: proj].

	"Find parent project, go there, zap old thumbnail"
	strm _ serverFile oldFileNamed: pair first.
	Project current installRemoteFrom: strm named: projName.

