smVersions
 
^ (self smReleasesForPackage: self package) collect: [ :v | self copy package: (v package name,'(',v version,')'); yourself. ] 

 