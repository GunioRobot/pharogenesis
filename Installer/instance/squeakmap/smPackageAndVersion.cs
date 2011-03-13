smPackageAndVersion

| p |

p := ReadStream on: self package .

^Array with: (p upTo: $() with: (p upTo: $)).