normalForFace: vi 

  "  vi  is a collection of vertex indices. Only the first three vertices are used to compute the normal. For planar faces this is correct. "

  | v1 v2 v3 d1 d2 |
    v1 _ vertices at: (vi at: 1).
    v2 _ vertices at: (vi at: 2).
    v3 _ vertices at: (vi at: 3).
    d1 _ v3 - v1.
    d2 _ v2 - v1.
    d1 safelyNormalize.
    d2 safelyNormalize.
    ^(d1 cross: d2) safelyNormalize.