printOn: s
 
s nextPutAll: '(Installer'.

self sm ifTrue: [ s nextPutAll: ' squeakmap' ].
self ma ifNotNil: [ s nextPutAll: ' mantis' ].
self wsm ifNotNil: [ s nextPutAll: ' websqueakmap' ].
self url ifNotNil: [ s nextPutAll: ' url:''', self url,'''' ].
self mc ifNotNil: [ s nextPutAll: ' repository:''', self mc,'''' ].

s nextPut: $).

self project ifNotNil: [ s nextPutAll: ' project:';
  						nextPutAll: '''', self project, ''''.
					   self package ifNotNil: [ s nextPutAll: '; '] ].
					
self package ifNotNil: [ s nextPutAll: ' package:';
  						 nextPutAll: '''', self package asString, '''' ].
					
s nextPut: $..