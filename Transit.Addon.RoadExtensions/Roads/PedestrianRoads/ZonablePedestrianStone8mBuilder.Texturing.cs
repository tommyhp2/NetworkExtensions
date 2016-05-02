﻿using Transit.Addon.RoadExtensions.Compatibility;
using Transit.Framework;
using Transit.Framework.Texturing;

namespace Transit.Addon.RoadExtensions.Roads.PedestrianRoads
{
    public partial class ZonablePedestrianStone8mBuilder
    {
        private static void SetupTextures(NetInfo info, NetInfoVersion version)
        {
            switch (version)
            {
                case NetInfoVersion.Ground:
                    {
                        info.SetAllSegmentsTexture(
                            new TextureSet
                               (@"Roads\PedestrianRoads\Textures\Stone8m\Ground_Segment__MainTex.png",
                                @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Segment__AlphaMap.png",
                                @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Segment__XYSMap.png"),
                            new LODTextureSet
                                (@"Roads\PedestrianRoads\Textures\Stone8m\Ground_Segment_LOD__MainTex.png",
                                @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Segment_LOD__AlphaMap.png",
                                @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Segment_LOD__XYSMap.png"));
                        for (int i = 0; i < info.m_nodes.Length; i++)
                        {
                            if (info.m_nodes[i].m_mesh.name.ToLower().IndexOf("trans") == -1)
                            {
                                info.m_nodes[i].SetTextures(
                                    new TextureSet
                                       (@"Roads\PedestrianRoads\Textures\Stone8m\Ground_Node__MainTex.png",
                                        @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Node__AlphaMap.png",
                                        @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Node__XYSMap.png"),
                                    new LODTextureSet
                                        (@"Roads\PedestrianRoads\Textures\Stone8m\Ground_Node_LOD__MainTex.png",
                                        @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Node_LOD__AlphaMap.png"));
                            }
                            else
                            {
                                info.m_nodes[i].SetTextures(
                                    new TextureSet
                                       (@"Roads\PedestrianRoads\Textures\Stone8m\Ground_Trans__MainTex.png",
                                        @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Trans__AlphaMap.png"),
                                    new LODTextureSet
                                        (@"Roads\PedestrianRoads\Textures\Stone8m\Ground_Trans_LOD__MainTex.png",
                                        @"Roads\PedestrianRoads\Textures\Stone8m\Ground_Trans_LOD__AlphaMap.png"));
                            }
                        }

                        break;
                    }
                case NetInfoVersion.Elevated:
                case NetInfoVersion.Bridge:
                    { 
                    info.SetAllSegmentsTexture(
                        new TextureSet
                           (@"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Segment__MainTex.png",
                            @"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Segment__AlphaMap.png",
                            @"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Segment__XYSMap.png"),
                        new LODTextureSet
                            (@"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Segment_LOD__MainTex.png",
                            @"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Segment_LOD__AlphaMap.png",
                            @"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Segment_LOD__XYSMap.png"));
                    for (int i = 0; i < info.m_nodes.Length; i++)
                    {
                        if (info.m_nodes[i].m_mesh.name.ToLower().IndexOf("trans") == -1)
                        {
                            info.m_nodes[i].SetTextures(
                                new TextureSet
                                   (@"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Node__MainTex.png",
                                    @"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Node__AlphaMap.png"));
                        }
                        else
                        {
                            info.m_nodes[i].SetTextures(
                                new TextureSet
                                   (@"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Trans__MainTex.png",
                                    @"Roads\PedestrianRoads\Textures\Stone8m\Elevated_Trans__AlphaMap.png"));
                        }
                    }

                    break;
                        }
            }
        }
    }
}