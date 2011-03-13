packagesMatching: aMatch

self sm ifTrue: [ ^ (self packages select: [ :p | aMatch match: p name ]) collect: [ :p | self copy package: p name; yourself ] ].
self mc ifNotNil: [ ^ (self packages select: [ :p | ( aMatch , '.mcz' ) match: p ]) collect: [ :p | self copy package: p ; yourself ] ].
self wsm ifNotNil: [ ^ (self packages select: [ :p | ( aMatch) match: p ]) collect: [ :p | self copy package: p ; yourself ] ].

^'search type not supported'