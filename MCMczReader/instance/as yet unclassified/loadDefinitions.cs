loadDefinitions
	definitions _ OrderedCollection new.
	(zip memberNamed: 'snapshot.bin') ifNotNilDo:
		[:m | ^ definitions _ (DataStream on: m contentStream) next definitions].
	"otherwise"
	(self zip membersMatching: 'snapshot/*')
		do: [:m | self extractDefinitionsFrom: m].
