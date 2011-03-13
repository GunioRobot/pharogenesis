mcVersions

^ (self packages select: [ :p | ( self package,'-*.mcz' ) match: p ]) collect: [ :p | self copy package: p  ; yourself ].
 