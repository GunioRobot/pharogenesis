install

self logErrorDuring: [
	self mc ifNotNil: [ ^self mcInstall ].
	self wsm ifNotNil: [ ^self wsmInstall ].
	self sm ifTrue: [ ^self smInstall ].
	self url ifNotNil: [ ^self urlInstall ].
	self package ifNotNil: [ ^self webInstall ].
] 