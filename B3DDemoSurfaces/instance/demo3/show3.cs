show3

    " B3DDemoSurfaces new show3"

     | view |

  self createScene3.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene3;
     scene: scene.
  view clearColor: (Color gray: 0.86).

  view rotateZ: 12.0.
  view openInSystemWindow